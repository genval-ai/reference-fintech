# Account Management
Manages banking account operations including balance queries and transfers

**Capability Metadata**
| Property | Value |
|----------|------|
| Capability Code | `account-management` |
| Capability Image | ![Account Management Capability Small Image](./images/account-management_small.png) |

## Capability Operations

<a name="get-account-balances"></a>
### Get Account Balances
Retrieves balances for all accounts owned by a customer

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `get-account-balances` |

#### Input Schema
```json Get Account Balances operation input schema
{
  "type": "object",
  "properties": {
    "customerId": "string"
  }
}
```

#### Output Schema
```json Get Account Balances operation output schema
{
  "type": "object",
  "properties": {
    "accounts": {
      "type": "array",
      "items": {
        "type": "object",
        "properties": {
          "accountId": "string",
          "type": "string",
          "balance": "number",
          "currency": "string"
        }
      }
    }
  }
}
```
<a name="internal-transfer"></a>
### Internal Transfer
Processes transfers between accounts within the same bank

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `internal-transfer` |

#### Input Schema
```json Internal Transfer operation input schema
{
  "type": "object",
  "properties": {
    "fromAccountId": "string",
    "toAccountId": "string",
    "amount": "number",
    "currency": "string"
  }
}
```

#### Output Schema
```json Internal Transfer operation output schema
{
  "type": "object",
  "properties": {
    "transferId": "string",
    "status": "string"
  }
}
```
<a name="international-wire"></a>
### International Wire Transfer
Processes international wire transfers to external banks

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `international-wire` |

#### Input Schema
```json International Wire Transfer operation input schema
{
  "type": "object",
  "properties": {
    "fromAccountId": "string",
    "recipientBank": "string",
    "recipientAccount": "string",
    "amount": "number",
    "currency": "string",
    "swiftCode": "string"
  }
}
```

#### Output Schema
```json International Wire Transfer operation output schema
{
  "type": "object",
  "properties": {
    "wireId": "string",
    "status": "string",
    "estimatedDelivery": "string"
  }
}
```
