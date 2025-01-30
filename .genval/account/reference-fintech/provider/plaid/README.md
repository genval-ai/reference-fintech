# Plaid
Plaid is a financial services platform that enables applications to connect with users' bank accounts.

**Provider Metadata**
| Property | Value |
|----------|------|
| Provider Code | `plaid` |
| Provider Image |![Plaid Provider Small Image](./images/plaid_small.png) |

## Provider Connection Types

<a name="plaid_banking"></a>
### Plaid Banking
Integration with Plaid's banking APIs for account management and transfers

**Connection Type Metadata**
| Property | Value|
|----------|------|
| Connection Type Code | `plaid_banking` |

<a name="plaid_banking_client_id"></a>
#### Client ID
Your Plaid client identifier

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `client_id` |
| IsSecret | False |
| Property Level | client |
| Requried | True |
| Example Value | plaid_client_12345 |

<a name="plaid_banking_secret"></a>
#### Secret
Your Plaid secret key

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `secret` |
| IsSecret | True |
| Property Level | client |
| Requried | True |
| Example Value | plaid_sk_12345 |

<a name="plaid_banking_environment"></a>
#### Environment
Plaid environment (sandbox, development, or production)

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `environment` |
| IsSecret | False |
| Property Level | client |
| Requried | True |
| Example Value | sandbox |



