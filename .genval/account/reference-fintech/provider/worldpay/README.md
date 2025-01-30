# Worldpay
We power global commerce by providing exceptional payments technology and expertise to businesses. Find out how Worldpay can help you.

**Provider Metadata**
| Property | Value |
|----------|------|
| Provider Code | `worldpay` |
| Provider Image |![Worldpay Provider Small Image](./images/worldpay_small.png) |

## Provider Connection Types

### Worldpay Default Connection
Default connection type for integrating with Worldpay payment services

**Connection Type Metadata**
| Property | Value|
|----------|------|
| Connection Type Code | `worldpay_default` |

#### Merchant Code
Your Worldpay merchant code identifier

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `merchant_code` |
| IsSecret | False |
| Property Level | client |
| Requried | False |
| Example Value | MERCHANT123 |

#### API Key
Your Worldpay API key for authentication

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `api_key` |
| IsSecret | False |
| Property Level | client |
| Requried | False |
| Example Value | T23MKEY98B1234567 |

#### Environment
Worldpay environment (test or production)

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `environment` |
| IsSecret | False |
| Property Level | client |
| Requried | False |
| Example Value | test |

#### Notification Secret
Secret key for validating Worldpay webhook notifications

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `notification_secret` |
| IsSecret | False |
| Property Level | client |
| Requried | False |
| Example Value | notif_secret_12345 |



