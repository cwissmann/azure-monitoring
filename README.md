# Azure Monitoring

Short entrypoint for Azure Monitoring

## Getting Started

Setup example infrastructure

### Create infrastructure with Azure Resource Manager template

Install [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-windows?view=azure-cli-latest#install-or-update)

Login to your Azure Subscription
```
az login
```

Check that the subscription, you want to use, is default
```
az account set --subscription SUBSRIPTION
```

Create new resource group. That makes it easier to delete all the stuff from this demo later.
```
az group create --name GROUPNAME --location westeurope
```

Run the template to deploy the initial infrastructure
```
az deployment group create --resource-group GROUPNAME --template-file .\infrastructure\azuredeploy.json
```

### Deploy logic

Deploy **functionNet01** to the associated Azure function.

### Configure ApplicationInsights

Open appinsights01 resource on Azure. 
