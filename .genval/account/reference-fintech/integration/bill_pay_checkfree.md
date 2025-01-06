# Bill Pay via CheckFree
Integrate CheckFree Pay's payment processing services with the bill payment capability to enable secure and reliable bill payments through CheckFree's extensive biller network.

### Integration Metadata
| Property | Value |
|----------|------|
| Integration Code | `bill_pay_checkfree` |

### Capability
| Property | Value |
|----------|------|
| Capability Name | [Bill Payment](../capability/bill_pay.md) |
| Capability Code | `bill_pay` |

### Provider Connection Type
| Property | Value |
|----------|------|
| Provider Name | [CheckFree](../provider/checkfree.md) |
| Provider Code | `checkfree` |
| Connection Type Name | [CheckFree Pay](../provider/checkfree.md#checkfree_pay) |
| Connection Type Code | `checkfree_pay` |

## Integration Instructions
To implement this integration:

1. Map the bill_pay capability's billerId to CheckFree's biller_id format
2. Ensure payment methods align with CheckFree's supported methods:
   - bank_account -> ACH
   - debit_card -> DEBIT
   - credit_card -> CREDIT
3. Use CheckFree's API key and merchant_id for authentication
4. For pay_bill operation:
   - Call CheckFree's /payments/create endpoint
   - Map transactionId to CheckFree's payment_id
5. For get_bill_status:
   - Use CheckFree's /payments/{payment_id}/status endpoint
6. For schedule_payment:
   - Use CheckFree's /payments/schedule endpoint
   - Store scheduleId from response
7. Implement webhook handling for payment status updates
8. Add error handling for CheckFree-specific response codes