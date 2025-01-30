# Account Management via Finastra Fusion
Integrates core banking account management operations with Finastra's Fusion platform for balance inquiries and transfer processing

### Integration Metadata
| Property | Value |
|----------|------|
| Integration Code | `am_finastra_fusion` |

### Capability
| Property | Value |
|----------|------|
| Capability Name | [Account Management](../../capability/account-management) |
| Capability Code | `account-management` |
| Capability Image | ![Account Management Capability Square Image](../../capability/account-management/images/account-management_square.png) |

### Provider Connection Type
| Property | Value |
|----------|------|
| Provider Name | [Finastra](../../provider/finastra) |
| Provider Code | `finastra` |
| Provider Image | ![Finastra Provider Square Image](../../provider/finastra/images/finastra_square.png) |
| Connection Type Name | [Finastra Fusion](../../provider/finastra#finastra_fusion) |
| Connection Type Code | `finastra_fusion` |

## Integration Instructions
This integration implements account management operations using Finastra's Fusion APIs. Authentication is handled via OAuth 2.0 using the [client_id](../../provider/finastra#finastra_fusion_client_id) and [client_secret](../../provider/finastra#finastra_fusion_client_secret) credentials.

1. Authentication:
   - Request an access token from Finastra's OAuth endpoint using client credentials
   - Include the token in all API requests as a Bearer token in the Authorization header
   - Token endpoint varies by [region](../../provider/finastra#finastra_fusion_region)

2. Operation Implementation Details:

[get-account-balances](../../capability/account-management#get-account-balances)
- Maps to Finastra's GET /accounts/balances endpoint
- The customerId input parameter maps to Finastra's partyId
- Response transformation required to map Finastra's balance format to capability schema
- Handles multiple currency accounts and aggregate balances

[internal-transfer](../../capability/account-management#internal-transfer)
- Uses Finastra's POST /transfers/internal endpoint
- Requires real-time validation of source account funds
- Implements idempotency using X-Idempotency-Key header
- Returns transferId from Finastra's response correlation ID
- Maps status values: COMPLETED, PENDING, REJECTED

[international-wire](../../capability/account-management#international-wire)
- Corresponds to Finastra's POST /transfers/international endpoint
- SWIFT code validation required before submission
- Currency conversion handled automatically by Finastra
- Estimated delivery calculated based on cut-off times and destination country
- Status mapping:
  * INITIATED -> 'pending'
  * PROCESSED -> 'completed'
  * FAILED -> 'rejected'

Error Handling:
- HTTP 401/403: Re-authenticate and retry once
- HTTP 429: Implement exponential backoff retry
- HTTP 500: No retry, surface error to caller

Rate Limits:
- Balance queries: 100/minute
- Transfers: 50/minute
- Consider implementing request throttling

Refer to Finastra's API documentation at https://developer.fusionfabric.cloud/documentation for detailed endpoint specifications and response codes.

Testing:
- Use Finastra's sandbox environment for integration testing
- Test credentials can be obtained from the Finastra Developer Portal
- Validate all currency conversion scenarios
- Verify timeout handling and retry logic