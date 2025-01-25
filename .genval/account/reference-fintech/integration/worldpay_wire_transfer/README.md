# Worldpay International Wire Transfer Integration
Integrates Worldpay's payment infrastructure with international wire transfer capabilities, enabling secure cross-border payments and real-time transaction validation.

### Integration Metadata
| Property | Value |
|----------|------|
| Integration Code | `worldpay_wire_transfer` |

### Capability
| Property | Value |
|----------|------|
| Capability Name | [International Wire Transfer](../../capability/international_wire_transfer) |
| Capability Code | `international_wire_transfer` |
| Capability Image | ![International Wire Transfer Capability Square Image](../../capability/international_wire_transfer/images/international_wire_transfer_square.png) |

### Provider Connection Type
| Property | Value |
|----------|------|
| Provider Name | [Worldpay](../../provider/worldpay) |
| Provider Code | `worldpay` |
| Provider Image | ![Worldpay Provider Square Image](../../provider/worldpay/images/worldpay_square.png) |
| Connection Type Name | [Worldpay Default Connection](../../provider/worldpay#worldpay_default) |
| Connection Type Code | `worldpay_default` |

## Integration Instructions
1. Configure the Worldpay connection using your merchant credentials and API key.
2. For validate_wire_details: Use Worldpay's bank verification API to validate the SWIFT and IBAN details before proceeding.
3. For execute_wire_transfer: Map the transfer details to Worldpay's payment initiation endpoint, using the merchant_code for authorization.
4. For get_transfer_status: Use Worldpay's transaction lookup API with the returned transactionId to track payment status.
5. Implement webhook handling using the notification_secret to receive real-time status updates.
6. Ensure the environment setting matches your integration stage (test/production).