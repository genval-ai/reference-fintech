# Jack Henry Account Management Integration
Integrates core banking account management capabilities with Jack Henry's banking platform for balance inquiries and transfer operations.

### Integration Metadata
| Property | Value |
|----------|------|
| Integration Code | `jh_account_mgmt` |

### Capability
| Property | Value |
|----------|------|
| Capability Name | [Account Management](../../capability/account-management) |
| Capability Code | `account-management` |
| Capability Image | ![Account Management Capability Square Image](../../capability/account-management/images/account-management_square.png) |

### Provider Connection Type
| Property | Value |
|----------|------|
| Provider Name | [Jack Henry Banking](../../provider/jack_henry) |
| Provider Code | `jack_henry` |
| Provider Image | ![Jack Henry Banking Provider Square Image](../../provider/jack_henry/images/jack_henry_square.png) |
| Connection Type Name | [Jack Henry Core Banking](../../provider/jack_henry#jack_henry_core) |
| Connection Type Code | `jack_henry_core` |

## Integration Instructions
## Overview
This integration enables account management operations through Jack Henry's banking platform. All requests require authentication using the [api_key](../../provider/jack_henry#api_key) and must include the [institution_id](../../provider/jack_henry#institution_id). The [environment](../../provider/jack_henry#environment) setting determines whether operations are performed in sandbox or production.

## Operation Details

### Account Balances
To implement [get-account-balances](../../capability/account-management#get-account-balances), use Jack Henry's `/v1/customers/{customerId}/accounts` endpoint. The response will need to be transformed to match the capability's output schema by:
1. Mapping JH's account_number to accountId
2. Converting balance_amount to balance
3. Extracting currency_code to currency

### Internal Transfers
For [internal-transfer](../../capability/account-management#internal-transfer) operations, utilize the `/v1/transfers/internal` endpoint. Required steps:
1. Validate both accounts belong to your institution using the [institution_id](../../provider/jack_henry#institution_id)
2. Submit transfer request with source and destination accounts
3. Map the returned JH transfer_reference to transferId
4. Transform JH's transfer_state to appropriate status value

### International Wires
Implement [international-wire](../../capability/account-management#international-wire) using the `/v1/wires/international` endpoint. Implementation notes:
1. Convert provided currency and amount to ISO formats
2. Validate SWIFT code format before submission
3. Map wire_reference_number to wireId
4. Transform wire_status to status
5. Map estimated_settlement_date to estimatedDelivery

## Error Handling
- Handle HTTP 401 for invalid [api_key](../../provider/jack_henry#api_key)
- Handle HTTP 404 for invalid account numbers
- Handle HTTP 422 for validation errors (invalid currency, insufficient funds)
- Implement exponential backoff for rate limiting (HTTP 429)

## Testing
Use [environment](../../provider/jack_henry#environment)=sandbox for development and testing. Test accounts and predefined scenarios are available in the sandbox environment.