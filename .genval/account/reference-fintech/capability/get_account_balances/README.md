# Get Account Balances
Retrieves the current balances for one or more bank accounts associated with a user.

**Capability Metadata**
| Property | Value |
|----------|------|
| Capability Code | `get_account_balances` |
| Capability Image | ![Get Account Balances Capability Small Image](./images/get_account_balances_small.png) |

## Capability Operations

<a name="get_balance"></a>
### Get Balance
Retrieves the current balance for specified accounts

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `get_balance` |

#### Input Schema
```json Get Balance operation input schema
{
  "type": "object",
  "properties": {
    "accountIds": {
      "type": "array",
      "items": {
        "type": "string"
      },
      "description": "List of account IDs to get balances for"
    }
  },
  "required": [
    "accountIds"
  ]
}
```

#### Output Schema
```json Get Balance operation output schema
{
  "type": "object",
  "properties": {
    "balances": {
      "type": "array",
      "items": {
        "type": "object",
        "properties": {
          "accountId": {
            "type": "string"
          },
          "currentBalance": {
            "type": "number"
          },
          "availableBalance": {
            "type": "number"
          },
          "currency": {
            "type": "string"
          },
          "lastUpdated": {
            "type": "string",
            "format": "date-time"
          }
        },
        "required": [
          "accountId",
          "currentBalance",
          "availableBalance",
          "currency",
          "lastUpdated"
        ]
      }
    }
  }
}
```
