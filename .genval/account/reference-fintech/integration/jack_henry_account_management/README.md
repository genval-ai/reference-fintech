# Jack Henry Account Management Integration
Integrates core banking operations with Jack Henry's banking platform for account management, balance queries, and transfer operations.

### Integration Metadata
| Property | Value |
|----------|------|
| Integration Code | `jack_henry_account_management` |

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
This integration enables account management operations through Jack Henry's core banking platform. Authentication and institution identification are required using the [api_key](../../provider/jack_henry#jack_henry_core_api_key) and [institution_id](../../provider/jack_henry#jack_henry_core_institution_id) properties. The [environment](../../provider/jack_henry#jack_henry_core_environment) setting determines whether operations are performed in sandbox or production.

## Operations Implementation

### Account Balance Retrieval
To implement [get-account-balances](../../capability/account-management#get-account-balances):
1. Send GET request to `/v1/institutions/{institution_id}/customers/{customerId}/accounts`
2. Include API Key in Authorization header
3. Response data should be mapped to match the operation's output schema:
   - Map account.id to accountId
   - Map account.accountType to type
   - Map account.currentBalance to balance
   - Map account.currencyCode to currency

### Internal Transfers
To implement [internal-transfer](../../capability/account-management#internal-transfer):
1. Send POST request to `/v1/institutions/{institution_id}/transfers/internal`
2. Include transfer details in request body:
   - fromAccountId
   - toAccountId
   - amount
   - currency
3. Response will include:
   - transferId: unique identifier for the transfer
   - status: 'COMPLETED', 'PENDING', or 'FAILED'

### International Wire Transfers
To implement [international-wire](../../capability/account-management#international-wire):
1. Send POST request to `/v1/institutions/{institution_id}/transfers/wire`
2. Include wire transfer details in request body:
   - fromAccountId
   - recipientBank
   - recipientAccount
   - amount
   - currency
   - swiftCode
3. Response will include:
   - wireId: unique identifier for the wire transfer
   - status: 'PROCESSING', 'COMPLETED', or 'FAILED'
   - estimatedDelivery: ISO 8601 datetime

## Error Handling
- HTTP 401: Invalid API credentials
- HTTP 404: Invalid institution_id or account not found
- HTTP 400: Invalid request parameters
- HTTP 422: Business validation errors (insufficient funds, account restrictions)

Implement appropriate error handling and retries based on response codes and error messages.