# Stripe
Stripe provides payment infrastructure and financial services APIs.

**Provider Metadata**
| Property | Value |
|----------|------|
| Provider Code | `stripe` |
| Provider Image |![Stripe Provider Small Image](./images/stripe_small.png) |

## Provider Connection Types

<a name="stripe_connect"></a>
### Stripe Connect
Integration with Stripe's banking and transfer APIs

**Connection Type Metadata**
| Property | Value|
|----------|------|
| Connection Type Code | `stripe_connect` |

<a name="stripe_connect_secret_key"></a>
#### Secret Key
Your Stripe secret key

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `secret_key` |
| IsSecret | True |
| Property Level | client |
| Requried | True |
| Example Value | sk_live_1234567890 |

<a name="stripe_connect_webhook_secret"></a>
#### Webhook Secret
Secret for validating webhook signatures

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `webhook_secret` |
| IsSecret | True |
| Property Level | client |
| Requried | True |
| Example Value | whsec_1234567890 |



