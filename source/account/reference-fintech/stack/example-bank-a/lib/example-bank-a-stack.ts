import * as cdk from 'aws-cdk-lib';
import * as apigateway from 'aws-cdk-lib/aws-apigateway';
import * as lambda from 'aws-cdk-lib/aws-lambda';
import * as iam from 'aws-cdk-lib/aws-iam';
import { Construct } from 'constructs';

export class ExampleBankAStack extends cdk.Stack {
  constructor(scope: Construct, id: string, props?: cdk.StackProps) {
    super(scope, id, props);

    // Create Lambda functions
    const billPayFunction = new lambda.Function(this, 'BillPayFunction', {
      runtime: lambda.Runtime.NODEJS_18_X,
      handler: 'BillPayCheckFreeFunction.handler',
      code: lambda.Code.fromAsset('../integration/bill_pay_checkfree'),
    });

    const fraudDetectionFunction = new lambda.Function(this, 'FraudDetectionFunction', {
      runtime: lambda.Runtime.NODEJS_18_X,
      handler: 'FiservSecureNowFraudDetectionFunction.handler',
      code: lambda.Code.fromAsset('../integration/fiserv_securenow_fraud_detection'),
    });

    const moneyTransferFunction = new lambda.Function(this, 'MoneyTransferFunction', {
      runtime: lambda.Runtime.NODEJS_18_X,
      handler: 'WorldpayMoneyTransferFunction.handler',
      code: lambda.Code.fromAsset('../integration/worldpay_money_transfer'),
    });

    // Create API Gateway
    const api = new apigateway.HttpApi(this, 'ExampleBankAApi', {
      apiName: 'Example Bank A API',
      createDefaultStage: true,
    });

    // Add routes to API Gateway
    api.addRoutes({
      path: '/bill_pay/{proxy+}',
      methods: [apigateway.HttpMethod.ANY],
      integration: new apigateway.HttpLambdaIntegration('BillPayIntegration', billPayFunction),
    });

    api.addRoutes({
      path: '/fraud_detection/{proxy+}',
      methods: [apigateway.HttpMethod.ANY],
      integration: new apigateway.HttpLambdaIntegration('FraudDetectionIntegration', fraudDetectionFunction),
    });

    api.addRoutes({
      path: '/money_transfer/{proxy+}',
      methods: [apigateway.HttpMethod.ANY],
      integration: new apigateway.HttpLambdaIntegration('MoneyTransferIntegration', moneyTransferFunction),
    });

    // Grant permissions to Lambda functions
    billPayFunction.addPermission('ApiGatewayInvoke', {
      principal: new iam.ServicePrincipal('apigateway.amazonaws.com'),
      sourceArn: api.httpApiArn,
    });

    fraudDetectionFunction.addPermission('ApiGatewayInvoke', {
      principal: new iam.ServicePrincipal('apigateway.amazonaws.com'),
      sourceArn: api.httpApiArn,
    });

    moneyTransferFunction.addPermission('ApiGatewayInvoke', {
      principal: new iam.ServicePrincipal('apigateway.amazonaws.com'),
      sourceArn: api.httpApiArn,
    });

    // Output the API URL
    new cdk.CfnOutput(this, 'ApiUrl', {
      value: api.url ?? 'Something went wrong with the deployment',
      description: 'HTTP API endpoint URL',
    });
  }
}