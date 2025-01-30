# Tenant Management
Manages multi-tenant configuration and branding settings for banking institutions

**Capability Metadata**
| Property | Value |
|----------|------|
| Capability Code | `tenant-management` |
| Capability Image | ![Tenant Management Capability Small Image](./images/tenant-management_small.png) |

## Capability Operations

<a name="get-tenant-branding"></a>
### Get Tenant Branding
Retrieves the current branding configuration for a specific tenant

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `get-tenant-branding` |

#### Input Schema
```json Get Tenant Branding operation input schema
{
  "type": "object",
  "properties": {
    "tenantId": {
      "type": "string"
    }
  }
}
```

#### Output Schema
```json Get Tenant Branding operation output schema
{
  "type": "object",
  "properties": {
    "logo": "string",
    "primaryColor": "string",
    "secondaryColor": "string",
    "fontFamily": "string",
    "customCss": "string"
  }
}
```
<a name="update-tenant-branding"></a>
### Update Tenant Branding
Updates the branding configuration for a specific tenant

**Operation Metadata**
| Property | Value |
|----------|------|
| Operation Code | `update-tenant-branding` |

#### Input Schema
```json Update Tenant Branding operation input schema
{
  "type": "object",
  "properties": {
    "tenantId": {
      "type": "string"
    },
    "logo": "string",
    "primaryColor": "string",
    "secondaryColor": "string",
    "fontFamily": "string",
    "customCss": "string"
  }
}
```

#### Output Schema
```json Update Tenant Branding operation output schema
{
  "type": "object",
  "properties": {
    "success": "boolean"
  }
}
```
