# Bill Payment
Pay bills online through various payment providers and services.

**Capability Metadata**
| Property | Value |
|----------|------|
| Capability Code | `bill_pay` |

## Capability Operations

### Pay a Bill
Process a bill payment for a specified amount to a designated biller.

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `pay_bill` |

#### Input Schema
```json operation input schema
{
  "type": "object",
  "properties": {
    "billerId": {
      "type": "string"
    },
    "accountNumber": {
      "type": "string"
    },
    "amount": {
      "type": "number",
      "minimum": 0
    },
    "dueDate": {
      "type": "string",
      "format": "date"
    },
    "paymentMethod": {
      "type": "string",
      "enum": [
        "bank_account",
        "debit_card",
        "credit_card"
      ]
    }
  },
  "required": [
    "billerId",
    "accountNumber",
    "amount"
  ]
}
```

#### Output Schema
```json operation output schema
{
  "type": "object",
  "properties": {
    "transactionId": {
      "type": "string"
    },
    "status": {
      "type": "string",
      "enum": [
        "success",
        "pending",
        "failed"
      ]
    },
    "confirmationNumber": {
      "type": "string"
    },
    "processingDate": {
      "type": "string",
      "format": "date-time"
    }
  },
  "required": [
    "transactionId",
    "status"
  ]
}
```
### Check Bill Payment Status
Retrieve the current status of a bill payment transaction.

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `get_bill_status` |

#### Input Schema
```json operation input schema
{
  "type": "object",
  "properties": {
    "transactionId": {
      "type": "string"
    }
  },
  "required": [
    "transactionId"
  ]
}
```

#### Output Schema
```json operation output schema
{
  "type": "object",
  "properties": {
    "transactionId": {
      "type": "string"
    },
    "status": {
      "type": "string"
    },
    "processingDate": {
      "type": "string",
      "format": "date-time"
    },
    "completionDate": {
      "type": "string",
      "format": "date-time"
    }
  },
  "required": [
    "transactionId",
    "status"
  ]
}
```
### Schedule Future Payment
Schedule a bill payment for a future date.

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `schedule_payment` |

#### Input Schema
```json operation input schema
{
  "type": "object",
  "properties": {
    "billerId": {
      "type": "string"
    },
    "accountNumber": {
      "type": "string"
    },
    "amount": {
      "type": "number",
      "minimum": 0
    },
    "scheduledDate": {
      "type": "string",
      "format": "date"
    },
    "paymentMethod": {
      "type": "string"
    }
  },
  "required": [
    "billerId",
    "accountNumber",
    "amount",
    "scheduledDate"
  ]
}
```

#### Output Schema
```json operation output schema
{
  "type": "object",
  "properties": {
    "scheduleId": {
      "type": "string"
    },
    "status": {
      "type": "string"
    },
    "scheduledDate": {
      "type": "string",
      "format": "date"
    }
  },
  "required": [
    "scheduleId",
    "status"
  ]
}
```
