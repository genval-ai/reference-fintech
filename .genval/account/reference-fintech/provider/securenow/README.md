# SecureNow
SecureNow™ from Fiserv is a complete, real-time cyber security solution for digital banking designed to reduce friction for authentic users and meet the changing needs of the cyber security landscape.

**Provider Metadata**
| Property | Value |
|----------|------|
| Provider Code | `securenow` |
| Provider Image |![SecureNow Provider Small Image](./images/securenow_small.png) |

## Provider Connection Types

### Fiserv SecureNow
Connect to Fiserv SecureNow APIs for authentication and authorization services.

**Connection Type Metadata**
| Property | Value|
|----------|------|
| Connection Type Code | `fiserv_securenow` |

#### Client ID
The client identifier provided by Fiserv SecureNow

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `client_id` |
| IsSecret | False |
| Property Level | client |
| Requried | False |
| Example Value | abc123def456 |

#### Client Secret
The client secret key provided by Fiserv SecureNow

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `client_secret` |
| IsSecret | False |
| Property Level | client |
| Requried | False |
| Example Value | xyz789secret |

#### API Endpoint
The base URL for the SecureNow API endpoint

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `api_endpoint` |
| IsSecret | False |
| Property Level | client |
| Requried | False |
| Example Value | https://api.securenow.fiserv.com |

#### Organization ID
The unique identifier for your organization in SecureNow

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `organization_id` |
| IsSecret | False |
| Property Level | client |
| Requried | False |
| Example Value | org_12345 |



