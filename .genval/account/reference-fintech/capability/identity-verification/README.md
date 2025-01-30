# Identity Verification
Handles customer identity verification and online banking account management

**Capability Metadata**
| Property | Value |
|----------|------|
| Capability Code | `identity-verification` |
| Capability Image | ![Identity Verification Capability Small Image](./images/identity-verification_small.png) |

## Capability Operations

<a name="verify-customer"></a>
### Verify Customer
Verifies a customer's banking relationship using account details

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `verify-customer` |

#### Input Schema
```json Verify Customer operation input schema
{
  "type": "object",
  "properties": {
    "accountNumber": "string",
    "customerId": "string",
    "dateOfBirth": "string"
  }
}
```

#### Output Schema
```json Verify Customer operation output schema
{
  "type": "object",
  "properties": {
    "isVerified": "boolean",
    "customerProfile": "object"
  }
}
```
<a name="create-banking-credentials"></a>
### Create Banking Credentials
Creates new online banking credentials for verified customers

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `create-banking-credentials` |

#### Input Schema
```json Create Banking Credentials operation input schema
{
  "type": "object",
  "properties": {
    "customerId": "string",
    "username": "string",
    "password": "string",
    "email": "string"
  }
}
```

#### Output Schema
```json Create Banking Credentials operation output schema
{
  "type": "object",
  "properties": {
    "success": "boolean",
    "userId": "string"
  }
}
```
<a name="configure-2fa"></a>
### Configure Two-Factor Authentication
Sets up or updates 2FA settings for a customer

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `configure-2fa` |

#### Input Schema
```json Configure Two-Factor Authentication operation input schema
{
  "type": "object",
  "properties": {
    "userId": "string",
    "preferredMethod": "string",
    "phoneNumber": "string",
    "email": "string"
  }
}
```

#### Output Schema
```json Configure Two-Factor Authentication operation output schema
{
  "type": "object",
  "properties": {
    "success": "boolean",
    "setupComplete": "boolean"
  }
}
```
