# Plaid Banking Integration
Integrates Plaid banking services for account balance retrieval and transfer operations using the Account Management capability.

### Integration Metadata
| Property | Value |
|----------|------|
| Integration Code | `plaid_bank_integration` |

### Capability
| Property | Value |
|----------|------|
| Capability Name | [Account Management](../../capability/account-management) |
| Capability Code | `account-management` |
| Capability Image | ![Account Management Capability Square Image](../../capability/account-management/images/account-management_square.png) |

### Provider Connection Type
| Property | Value |
|----------|------|
| Provider Name | [Plaid](../../provider/plaid) |
| Provider Code | `plaid` |
| Provider Image | ![Plaid Provider Square Image](../../provider/plaid/images/plaid_square.png) |
| Connection Type Name | [Plaid Banking](../../provider/plaid#plaid_banking) |
| Connection Type Code | `plaid_banking` |

## Integration Instructions
# Plaid Banking Integration Guide

This guide details how to implement the Account Management capability using Plaid's banking APIs. Before starting, ensure you have valid Plaid credentials and appropriate access levels.

## Prerequisites

1. Valid Plaid credentials: [client_id](../../provider/plaid#plaid_banking_client_id) and [secret](../../provider/plaid#plaid_banking_secret)
2. Configured [environment](../../provider/plaid#plaid_banking_environment) (sandbox/development/production)
3. Completed Plaid Link flow to obtain access_token for user accounts

## Operation Implementations

### Get Account Balances

To implement [get-account-balances](../../capability/account-management#get-account-balances), use Plaid's `/accounts/balance/get` endpoint:

1. Use the stored access_token for the customer
2. Call Plaid's balance endpoint (https://plaid.com/docs/api/products/#accountsbalanceget)
3. Transform the response to match the capability's output schema:
   - Map Plaid's account_id to accountId
   - Use account.type for type
   - Map account.balances.current to balance
   - Map account.balances.iso_currency_code to currency

### Internal Transfers

For [internal-transfer](../../capability/account-management#internal-transfer), utilize Plaid's Transfer API:

1. Verify both accounts belong to same institution using account_id prefix
2. Create transfer using Plaid's `/transfer/create` endpoint
3. Monitor transfer status using `/transfer/get`
4. Return transfer_id as transferId and current status

Reference: https://plaid.com/docs/api/products/#transfer

### International Wire Transfers

For [international-wire](../../capability/account-management#international-wire), implement using Plaid's Payment Initiation Service:

1. Create payment recipient using `/payment_initiation/recipient/create`
2. Initiate payment with `/payment_initiation/payment/create`
3. Monitor status with `/payment_initiation/payment/get`
4. Return payment_id as wireId and status
5. Calculate estimatedDelivery based on currency and destination

For detailed API information, visit https://plaid.com/docs/api/products/#payment-initiation

## Error Handling

Implement error handling for common scenarios:
- Invalid credentials
- Expired access tokens
- Insufficient funds
- Invalid account numbers
- API rate limiting

Refer to Plaid's error documentation: https://plaid.com/docs/errors/

## Security Considerations

1. Always use HTTPS for API calls
2. Store access tokens securely
3. Implement proper authentication before processing requests
4. Monitor and log all transfer activities
5. Implement transaction limits and notifications