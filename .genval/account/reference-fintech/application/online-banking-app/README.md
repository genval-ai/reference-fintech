# Multi-Tenant Online Banking Platform
A SaaS-based online banking platform that enables financial institutions to provide branded digital banking services to their customers

**Application Metadata**
| Property | Value |
|----------|------|
| Application Code | `online-banking-app` |
| Application Image | ![Multi-Tenant Online Banking Platform Application Square Image](./images/online-banking-app_small.png) |

## Application Features


### Bank Tenant Configuration
Allows banks to configure their branded instance of the platform

**Feature Metadata**
| Property | Value |
|----------|------|
| Feature Code | `tenant-configuration` |

**User Stories**
| Title | Code | Role | Objective | Benefit |
|-----------|------------|----------|---------------|-------------|
| Configure Bank Branding | `configure-branding` | Bank Administrator | customize the appearance of our banking portal with our logo, colors, and brand elements | customers will have a consistent brand experience when using online banking |

### Customer Account Creation
Enables bank customers to verify their identity and create online banking accounts

**Feature Metadata**
| Property | Value |
|----------|------|
| Feature Code | `customer-onboarding` |

**User Stories**
| Title | Code | Role | Objective | Benefit |
|-----------|------------|----------|---------------|-------------|
| Verify Banking Relationship | `verify-relationship` | Bank Customer | verify my existing banking relationship using my account details | I can prove I am an authorized customer of the bank |
| Create Online Banking Account | `create-online-account` | Bank Customer | create credentials for accessing online banking | I can securely access my accounts online |

### Security Configuration
Allows users to manage their security settings and 2FA options

**Feature Metadata**
| Property | Value |
|----------|------|
| Feature Code | `security-management` |

**User Stories**
| Title | Code | Role | Objective | Benefit |
|-----------|------------|----------|---------------|-------------|
| Configure Two-Factor Authentication | `setup-2fa` | Bank Customer | set up and manage my preferred 2FA methods | I can ensure secure access to my banking information |

### Account Balance View
Provides users with a comprehensive view of their account balances

**Feature Metadata**
| Property | Value |
|----------|------|
| Feature Code | `account-overview` |

**User Stories**
| Title | Code | Role | Objective | Benefit |
|-----------|------------|----------|---------------|-------------|
| View Account Balances | `view-balances` | Bank Customer | see balances for all my accounts in one place | I can quickly understand my financial position |

### Internal Money Transfers
Enables transfers between accounts within the same bank

**Feature Metadata**
| Property | Value |
|----------|------|
| Feature Code | `internal-transfers` |

**User Stories**
| Title | Code | Role | Objective | Benefit |
|-----------|------------|----------|---------------|-------------|
| Transfer Between Accounts | `transfer-between-accounts` | Bank Customer | move money between my different accounts | I can manage my funds across my accounts |

### International Wire Transfers
Facilitates international wire transfers to external banks

**Feature Metadata**
| Property | Value |
|----------|------|
| Feature Code | `international-wires` |

**User Stories**
| Title | Code | Role | Objective | Benefit |
|-----------|------------|----------|---------------|-------------|
| Create International Wire Transfer | `create-international-wire` | Bank Customer | send money to international bank accounts | I can make payments to recipients in other countries |
