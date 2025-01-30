# Finastra Tenant Branding Integration
Integrates tenant branding management capabilities with Finastra's Fusion platform for consistent brand management across banking applications

### Integration Metadata
| Property | Value |
|----------|------|
| Integration Code | `finastra_tenant_branding` |

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
# Finastra Tenant Branding Integration Guide

This integration enables management of tenant branding through Finastra's Fusion platform APIs. Authentication is handled using OAuth2.0 credentials.

## Prerequisites
- Valid Finastra Fusion API credentials ([client_id](../../provider/finastra#client_id) and [client_secret](../../provider/finastra#client_secret))
- Correct [region](../../provider/finastra#region) endpoint configuration

## Operation Implementations

### Get Tenant Branding
The [get-tenant-branding](../../capability/tenant-management#get-tenant-branding) operation retrieves branding configuration through the following steps:

1. Authenticate with Finastra using OAuth credentials
2. Call Finastra's tenant profile endpoint: `GET /fusion/v1/tenants/{tenantId}/branding`
3. Transform the response to match the capability's output schema:
   - Map 'brandingLogo' to 'logo'
   - Map 'brandColors.primary' to 'primaryColor'
   - Map 'brandColors.secondary' to 'secondaryColor'
   - Map 'typography.font' to 'fontFamily'
   - Map 'styleOverrides' to 'customCss'

### Update Tenant Branding
The [update-tenant-branding](../../capability/tenant-management#update-tenant-branding) operation updates branding settings through:

1. Authenticate with Finastra using OAuth credentials
2. Transform the input payload to Finastra's expected format:
   ```
   {
     "brandingLogo": input.logo,
     "brandColors": {
       "primary": input.primaryColor,
       "secondary": input.secondaryColor
     },
     "typography": {
       "font": input.fontFamily
     },
     "styleOverrides": input.customCss
   }
   ```
3. Call Finastra's update endpoint: `PUT /fusion/v1/tenants/{tenantId}/branding`
4. Return success based on 200 OK response

## Error Handling
- Authentication failures: Retry with refreshed OAuth token
- 404 errors: Indicate invalid tenant ID
- 400 errors: Validate input formatting (especially color codes and CSS)
- Network timeouts: Implement exponential backoff retry strategy

## Rate Limiting
Respect Finastra's rate limits:
- Maximum 100 requests per minute per tenant
- Implement request queuing if necessary