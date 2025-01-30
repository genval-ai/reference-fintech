# View Transaction History
Enables users to view their financial transaction history across their bank accounts, including details of deposits, withdrawals, and other financial activities.

**Capability Metadata**
| Property | Value |
|----------|------|
| Capability Code | `transaction_history_view` |
| Capability Image | ![View Transaction History Capability Small Image](./images/transaction_history_view_small.png) |

## Capability Operations

<a name="get_transactions"></a>
### Get Transaction History
Retrieves a list of transactions for a specified account within a date range

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `get_transactions` |

#### Input Schema
```json Get Transaction History operation input schema
{
  "type": "object",
  "properties": {
    "accountId": {
      "type": "string"
    },
    "startDate": {
      "type": "string",
      "format": "date"
    },
    "endDate": {
      "type": "string",
      "format": "date"
    },
    "page": {
      "type": "integer",
      "minimum": 1
    },
    "pageSize": {
      "type": "integer",
      "minimum": 1,
      "maximum": 100
    }
  },
  "required": [
    "accountId",
    "startDate",
    "endDate"
  ]
}
```

#### Output Schema
```json Get Transaction History operation output schema
{
  "type": "object",
  "properties": {
    "transactions": {
      "type": "array",
      "items": {
        "type": "object",
        "properties": {
          "id": {
            "type": "string"
          },
          "date": {
            "type": "string",
            "format": "date-time"
          },
          "description": {
            "type": "string"
          },
          "amount": {
            "type": "number"
          },
          "type": {
            "type": "string",
            "enum": [
              "credit",
              "debit"
            ]
          },
          "balance": {
            "type": "number"
          },
          "category": {
            "type": "string"
          }
        },
        "required": [
          "id",
          "date",
          "description",
          "amount",
          "type",
          "balance"
        ]
      }
    },
    "pagination": {
      "type": "object",
      "properties": {
        "totalItems": {
          "type": "integer"
        },
        "totalPages": {
          "type": "integer"
        },
        "currentPage": {
          "type": "integer"
        }
      }
    }
  },
  "required": [
    "transactions",
    "pagination"
  ]
}
```
<a name="get_transaction_details"></a>
### Get Transaction Details
Retrieves detailed information for a specific transaction

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `get_transaction_details` |

#### Input Schema
```json Get Transaction Details operation input schema
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
```json Get Transaction Details operation output schema
{
  "type": "object",
  "properties": {
    "id": {
      "type": "string"
    },
    "date": {
      "type": "string",
      "format": "date-time"
    },
    "description": {
      "type": "string"
    },
    "amount": {
      "type": "number"
    },
    "type": {
      "type": "string"
    },
    "balance": {
      "type": "number"
    },
    "category": {
      "type": "string"
    },
    "merchant": {
      "type": "object",
      "properties": {
        "name": {
          "type": "string"
        },
        "category": {
          "type": "string"
        },
        "location": {
          "type": "string"
        }
      }
    },
    "notes": {
      "type": "string"
    },
    "attachments": {
      "type": "array",
      "items": {
        "type": "string",
        "format": "uri"
      }
    }
  },
  "required": [
    "id",
    "date",
    "description",
    "amount",
    "type",
    "balance"
  ]
}
```
