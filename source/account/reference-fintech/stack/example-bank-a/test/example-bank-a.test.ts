import * as cdk from 'aws-cdk-lib';
import { Template } from 'aws-cdk-lib/assertions';
import * as ExampleBankA from '../lib/example-bank-a-stack';

test('Example Bank A Stack', () => {
  const app = new cdk.App();
  // WHEN
  const stack = new ExampleBankA.ExampleBankAStack(app, 'MyTestStack');
  // THEN
  const template = Template.fromStack(stack);

  template.hasResourceProperties('AWS::ApiGatewayV2::Api', {
    Name: 'Example Bank A API'
  });

  template.resourceCountIs('AWS::Lambda::Function', 3);

  template.hasResourceProperties('AWS::ApiGatewayV2::Route', {
    RouteKey: 'ANY /bill_pay/{proxy+}'
  });

  template.hasResourceProperties('AWS::ApiGatewayV2::Route', {
    RouteKey: 'ANY /fraud_detection/{proxy+}'
  });

  template.hasResourceProperties('AWS::ApiGatewayV2::Route', {
    RouteKey: 'ANY /money_transfer/{proxy+}'
  });
});