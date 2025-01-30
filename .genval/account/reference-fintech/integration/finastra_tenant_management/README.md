# Finastra Tenant Management Integration
Integrates tenant branding and configuration management with Finastra's Fusion platform for seamless customization of banking institution interfaces.

### Integration Metadata
| Property | Value |
|----------|------|
| Integration Code | `finastra_tenant_management` |

### Capability
| Property | Value |
|----------|------|
| Capability Name | [Tenant Management](../../capability/tenant-management) |
| Capability Code | `tenant-management` |
| Capability Image | ![Tenant Management Capability Square Image](../../capability/tenant-management/images/tenant-management_square.png) |

### Provider Connection Type
| Property | Value |
|----------|------|
| Provider Name | [Finastra](../../provider/finastra) |
| Provider Code | `finastra` |
| Provider Image | ![Finastra Provider Square Image](../../provider/finastra/images/finastra_square.png) |
| Connection Type Name | [Finastra Fusion](../../provider/finastra#finastra_fusion) |
| Connection Type Code | `finastra_fusion` |

## Integration Instructions
## Overview
This integration enables management of tenant branding configurations through Finastra's Fusion platform. It leverages Finastra's Bank Profile API to store and retrieve branding elements for each banking institution.

## Authentication
Before making any API calls, obtain an OAuth access token using the [client_id](../../provider/finastra#finastra_fusion_client_id) and [client_secret](../../provider/finastra#finastra_fusion_client_secret). The token should be included in the Authorization header of all requests.

## Regional Endpoint
All API requests should be directed to the appropriate Finastra endpoint based on the configured [region](../../provider/finastra#finastra_fusion_region).

## Implementation Details

### Getting Tenant Branding
To implement the [get-tenant-branding](../../capability/tenant-management#get-tenant-branding) operation:

1. Construct a GET request to `/fusion/banks/{tenantId}/profile/branding`
2. Map the Finastra response to the capability's output schema:
   - logo → branding.logoUrl
   - primaryColor → branding.colorScheme.primary
   - secondaryColor → branding.colorScheme.secondary
   - fontFamily → branding.typography.primaryFont
   - customCss → branding.customStyles

### Updating Tenant Branding
To implement the [update-tenant-branding](../../capability/tenant-management#update-tenant-branding) operation:

1. Construct a PUT request to `/fusion/banks/{tenantId}/profile/branding`
2. Transform the input schema to Finastra's expected format:
```json
{
  "branding": {
    "logoUrl": "${input.logo}",
    "colorScheme": {
      "primary": "${input.primaryColor}",
      "secondary": "${input.secondaryColor}"
    },
    "typography": {
      "primaryFont": "${input.fontFamily}"
    },
    "customStyles": "${input.customCss}"
  }
}
```

## Error Handling
- 401/403: Invalid or expired credentials - Refresh OAuth token
- 404: Tenant not found - Verify tenant ID exists
- 429: Rate limit exceeded - Implement exponential backoff
- 5xx: Server errors - Retry with backoff strategy

For detailed API specifications, refer to the [Finastra Developer Portal](https://developer.fusionfabric.cloud/documentation).