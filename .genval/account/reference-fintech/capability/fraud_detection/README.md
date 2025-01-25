# Fraud Detection and Mitigation
Service for detecting fraud risks and providing risk assessments for banking sessions and money movement transactions.

**Capability Metadata**
| Property | Value |
|----------|------|
| Capability Code | `fraud_detection` |
| Capability Image | ![Fraud Detection and Mitigation Capability Small Image](./images/fraud_detection_small.png) |

## Capability Operations

### Assess Session Risk
Evaluates the risk level of a banking session based on user behavior and context

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `assess_session_risk` |

#### Input Schema
```json Assess Session Risk operation input schema
{
  "type": "object",
  "properties": {
    "sessionId": {
      "type": "string"
    },
    "userId": {
      "type": "string"
    },
    "deviceInfo": {
      "type": "object"
    },
    "ipAddress": {
      "type": "string"
    },
    "timestamp": {
      "type": "string"
    }
  },
  "required": [
    "sessionId",
    "userId"
  ]
}
```

#### Output Schema
```json Assess Session Risk operation output schema
{
  "type": "object",
  "properties": {
    "riskLevel": {
      "type": "string",
      "enum": [
        "low",
        "medium",
        "high"
      ]
    },
    "riskScore": {
      "type": "number"
    },
    "factors": {
      "type": "array",
      "items": {
        "type": "string"
      }
    }
  },
  "required": [
    "riskLevel",
    "riskScore"
  ]
}
```
### Assess Transaction Risk
Evaluates the risk level of a money movement transaction

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `assess_transaction_risk` |

#### Input Schema
```json Assess Transaction Risk operation input schema
{
  "type": "object",
  "properties": {
    "transactionId": {
      "type": "string"
    },
    "amount": {
      "type": "number"
    },
    "sourceAccount": {
      "type": "string"
    },
    "destinationAccount": {
      "type": "string"
    },
    "timestamp": {
      "type": "string"
    }
  },
  "required": [
    "transactionId",
    "amount"
  ]
}
```

#### Output Schema
```json Assess Transaction Risk operation output schema
{
  "type": "object",
  "properties": {
    "riskLevel": {
      "type": "string",
      "enum": [
        "low",
        "medium",
        "high"
      ]
    },
    "riskScore": {
      "type": "number"
    },
    "recommendedAction": {
      "type": "string",
      "enum": [
        "approve",
        "review",
        "reject"
      ]
    }
  },
  "required": [
    "riskLevel",
    "riskScore",
    "recommendedAction"
  ]
}
```
