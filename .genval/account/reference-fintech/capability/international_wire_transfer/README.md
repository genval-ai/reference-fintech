# International Wire Transfer
Execute international wire transfers between bank accounts across different countries and currencies.

**Capability Metadata**
| Property | Value |
|----------|------|
| Capability Code | `international_wire_transfer` |
| Capability Image | ![International Wire Transfer Capability Small Image](./images/international_wire_transfer_small.png) |

## Capability Operations

### Validate Wire Transfer Details
Validates the recipient's bank details and wire transfer information before execution

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `validate_wire_details` |

#### Input Schema
```json Validate Wire Transfer Details operation input schema
{
  "type": "object",
  "properties": {
    "recipientName": {
      "type": "string"
    },
    "bankName": {
      "type": "string"
    },
    "swiftCode": {
      "type": "string"
    },
    "iban": {
      "type": "string"
    },
    "country": {
      "type": "string"
    },
    "currency": {
      "type": "string"
    }
  },
  "required": [
    "recipientName",
    "bankName",
    "swiftCode",
    "iban",
    "country",
    "currency"
  ]
}
```

#### Output Schema
```json Validate Wire Transfer Details operation output schema
{
  "type": "object",
  "properties": {
    "isValid": {
      "type": "boolean"
    },
    "validationMessages": {
      "type": "array",
      "items": {
        "type": "string"
      }
    }
  }
}
```
### Execute Wire Transfer
Processes the international wire transfer with the specified details and amount

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `execute_wire_transfer` |

#### Input Schema
```json Execute Wire Transfer operation input schema
{
  "type": "object",
  "properties": {
    "recipientName": {
      "type": "string"
    },
    "bankName": {
      "type": "string"
    },
    "swiftCode": {
      "type": "string"
    },
    "iban": {
      "type": "string"
    },
    "country": {
      "type": "string"
    },
    "currency": {
      "type": "string"
    },
    "amount": {
      "type": "number"
    },
    "reference": {
      "type": "string"
    }
  },
  "required": [
    "recipientName",
    "bankName",
    "swiftCode",
    "iban",
    "country",
    "currency",
    "amount"
  ]
}
```

#### Output Schema
```json Execute Wire Transfer operation output schema
{
  "type": "object",
  "properties": {
    "transactionId": {
      "type": "string"
    },
    "status": {
      "type": "string"
    },
    "executionDate": {
      "type": "string",
      "format": "date-time"
    },
    "fees": {
      "type": "number"
    }
  }
}
```
### Get Transfer Status
Retrieves the current status of a wire transfer by transaction ID

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `get_transfer_status` |

#### Input Schema
```json Get Transfer Status operation input schema
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
```json Get Transfer Status operation output schema
{
  "type": "object",
  "properties": {
    "transactionId": {
      "type": "string"
    },
    "status": {
      "type": "string"
    },
    "executionDate": {
      "type": "string",
      "format": "date-time"
    },
    "completionDate": {
      "type": "string",
      "format": "date-time"
    },
    "fees": {
      "type": "number"
    }
  }
}
```
