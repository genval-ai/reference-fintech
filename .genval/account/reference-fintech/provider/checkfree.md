# CheckFree
CheckFree was founded in 1981 as an electronic payment processing company and has become a leading provider of financial electronic commerce products and services.

**Provider Metadata**
| Property | Value |
|----------|------|
| Capability Code | `checkfree` |

## Provider Connection Types

### CheckFree Pay
CheckFree Pay payment service integration using CheckFree Pay APIs for payment processing and management.

**Connection Type Metadata**
| Property | Value|
|----------|------|
| Connection Type Code | `checkfree_pay` |

#### API Key
The API key provided by CheckFree Pay for authentication

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `api_key` |
| IsSecret | False |
| Property Level | client |
| Requried | False |
| Example Value | ck_live_1234567890abcdef |

#### Merchant ID
Your unique merchant identifier assigned by CheckFree Pay

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `merchant_id` |
| IsSecret | False |
| Property Level | client |
| Requried | False |
| Example Value | MERCH123456 |

#### Environment
The CheckFree Pay environment (production or sandbox)

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `environment` |
| IsSecret | False |
| Property Level | client |
| Requried | False |
| Example Value | sandbox |

#### Webhook Secret
Secret key for validating webhook notifications from CheckFree Pay

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `webhook_secret` |
| IsSecret | False |
| Property Level | client |
| Requried | False |
| Example Value | whsk_123456789abcdef |


