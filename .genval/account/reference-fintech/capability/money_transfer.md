# Money Transfer
Enables secure transfer of funds between accounts, supporting both internal transfers between own accounts and external transfers to other bank accounts.

**Capability Metadata**
| Property | Value |
|----------|------|
| Capability Code | `money_transfer` |

## Capability Operations

### Transfer Between Own Accounts
Transfer money between accounts owned by the same user

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `internal_transfer` |

#### Input Schema
```json operation input schema
{
  "type": "object",
  "properties": {
    "fromAccountId": {
      "type": "string"
    },
    "toAccountId": {
      "type": "string"
    },
    "amount": {
      "type": "number",
      "minimum": 0
    },
    "currency": {
      "type": "string",
      "pattern": "^[A-Z]{3}$"
    },
    "description": {
      "type": "string",
      "maxLength": 100
    }
  },
  "required": [
    "fromAccountId",
    "toAccountId",
    "amount",
    "currency"
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
        "completed",
        "pending",
        "failed"
      ]
    },
    "timestamp": {
      "type": "string",
      "format": "date-time"
    }
  },
  "required": [
    "transactionId",
    "status",
    "timestamp"
  ]
}
```
### Transfer to External Account
Transfer money to accounts at other banks

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `external_transfer` |

#### Input Schema
```json operation input schema
{
  "type": "object",
  "properties": {
    "fromAccountId": {
      "type": "string"
    },
    "recipientName": {
      "type": "string"
    },
    "recipientBank": {
      "type": "string"
    },
    "recipientAccountNumber": {
      "type": "string"
    },
    "amount": {
      "type": "number",
      "minimum": 0
    },
    "currency": {
      "type": "string",
      "pattern": "^[A-Z]{3}$"
    },
    "description": {
      "type": "string",
      "maxLength": 100
    }
  },
  "required": [
    "fromAccountId",
    "recipientName",
    "recipientBank",
    "recipientAccountNumber",
    "amount",
    "currency"
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
        "completed",
        "pending",
        "failed"
      ]
    },
    "estimatedCompletionTime": {
      "type": "string",
      "format": "date-time"
    },
    "fees": {
      "type": "number"
    }
  },
  "required": [
    "transactionId",
    "status",
    "estimatedCompletionTime"
  ]
}
```
