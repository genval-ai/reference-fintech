# Worldpay Money Transfer Integration
Integrates the Money Transfer capability with Worldpay's payment processing services to enable secure internal and external fund transfers through the Worldpay payment infrastructure.

### Integration Metadata
| Property | Value |
|----------|------|
| Integration Code | `worldpay_money_transfer` |

### Capability
| Property | Value |
|----------|------|
| Capability Name | [Money Transfer](../../capability/money_transfer) |
| Capability Code | `money_transfer` |
| Capability Image | ![Money Transfer Capability Square Image](../../capability/money_transfer/images/money_transfer_square.png) |

### Provider Connection Type
| Property | Value |
|----------|------|
| Provider Name | [Worldpay](../../provider/worldpay) |
| Provider Code | `worldpay` |
| Provider Image | ![Worldpay Provider Square Image](../../provider/worldpay/images/worldpay_square.png) |
| Connection Type Name | [Worldpay Default Connection](../../provider/worldpay#worldpay_default) |
| Connection Type Code | `worldpay_default` |

## Integration Instructions
To implement this integration:

1. For internal_transfer operations:
- Use the merchant_code to identify the transaction source
- Submit transfers via Worldpay's internal transfer API
- Map the capability's amount and currency to Worldpay's payment format
- Use the API key for authentication
- Store the Worldpay transaction reference as transactionId

2. For external_transfer operations:
- Ensure the environment property is correctly set
- Create a payment instruction using recipient details
- Apply any Worldpay-specific bank routing codes for recipientBank
- Use webhook notifications (validated with notification_secret) to update transaction status
- Calculate fees based on Worldpay's pricing structure

3. Common implementation notes:
- Always validate currency codes against Worldpay's supported currencies
- Implement proper error handling for Worldpay API responses
- Use the test environment for initial implementation and testing
- Implement webhook handlers for asynchronous status updates