# Fiserv SecureNow Fraud Detection Integration
Integrate Fiserv SecureNow's fraud detection capabilities to assess risk levels for banking sessions and transactions using their advanced security APIs.

### Integration Metadata
| Property | Value |
|----------|------|
| Integration Code | `fiserv_securenow_fraud_detection` |

### Capability
| Property | Value |
|----------|------|
| Capability Name | [Fraud Detection and Mitigation](../capability/fraud_detection.md) |
| Capability Code | `fraud_detection` |

### Provider Connection Type
| Property | Value |
|----------|------|
| Provider Name | [SecureNow](../provider/securenow.md) |
| Provider Code | `securenow` |
| Connection Type Name | [Fiserv SecureNow](../provider/securenow.md#fiserv_securenow) |
| Connection Type Code | `fiserv_securenow` |

## Integration Instructions
1. Configure the Fiserv SecureNow connection using your provided credentials (client_id, client_secret, api_endpoint, and organization_id).

2. For assess_session_risk:
- Map the session details to SecureNow's session analysis endpoint
- Use deviceInfo for device fingerprinting
- Convert the response risk scores to the required riskLevel enum (low/medium/high)

3. For assess_transaction_risk:
- Send transaction details to SecureNow's transaction risk API
- Include the amount and account details as specified
- Map SecureNow's risk assessment to the required riskLevel and recommendedAction fields

4. Ensure proper error handling and timeout configurations.

5. Implement retry logic for API failures.

6. Cache risk decisions according to your compliance requirements.