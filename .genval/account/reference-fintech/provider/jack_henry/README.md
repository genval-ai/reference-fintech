# Jack Henry Banking
Jack Henry Banking is a leading provider of core banking software and technology solutions for financial institutions.

**Provider Metadata**
| Property | Value |
|----------|------|
| Provider Code | `jack_henry` |
| Provider Image |![Jack Henry Banking Provider Small Image](./images/jack_henry_small.png) |

## Provider Connection Types

<a name="jack_henry_core"></a>
### Jack Henry Core Banking
Integration with Jack Henry's core banking platform for managing bank profiles and settings

**Connection Type Metadata**
| Property | Value|
|----------|------|
| Connection Type Code | `jack_henry_core` |

<a name="_api_key"></a>
#### API Key
Authentication key for Jack Henry Banking API

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `api_key` |
| IsSecret | True |
| Property Level | client |
| Requried | True |
| Example Value | jh_live_key_123456 |

<a name="_institution_id"></a>
#### Institution ID
Your financial institution's unique identifier

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `institution_id` |
| IsSecret | False |
| Property Level | client |
| Requried | True |
| Example Value | FI123456 |

<a name="_environment"></a>
#### Environment
The Jack Henry environment (production or sandbox)

**Connection Property Metadata**
| Property | Value|
|----------|------|
| Property Code | `environment` |
| IsSecret | False |
| Property Level | client |
| Requried | True |
| Example Value | sandbox |



