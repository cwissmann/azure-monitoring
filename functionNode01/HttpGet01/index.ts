import { AzureFunction, Context, HttpRequest } from "@azure/functions"

let appInsights = require('applicationinsights');
appInsights.setup('6dd7c44d-17ee-4e49-ac58-df7672c4ff34');
appInsights.start();
let client = appInsights.defaultClient;

const httpTrigger: AzureFunction = async function (context: Context, req: HttpRequest): Promise<void> {
    context.log('HTTP trigger function processed a request.');
    const name = (req.query.name || (req.body && req.body.name));

    client.trackEvent({name: "NodeEvent", properties: {prop1: "Prop1"}});
    client.trackException({exception: new Error("NodeException from node function")});
    client.trackMetric({name: "NodeMetric", value: Math.random()});
    client.trackTrace({message: "Node trace message"});    

    if (name) {
        context.res = {
            // status: 200, /* Defaults to 200 */
            body: "Hello " + (req.query.name || req.body.name)
        };
    }
    else {
        context.res = {
            status: 400,
            body: "Please pass a name on the query string or in the request body"
        };
    }
};

export default httpTrigger;
