# Puppeteer Azure Functions on Docker

A base Docker image of an Azure Function App with [Puppeteer](https://github.com/GoogleChrome/puppeteer) installed.  
Create Puppeteer scripts which can be deployed as web services on Azure.

## Run the Examples

```sh
docker pull deniskyashif/puppeteer-azure-func
docker run -p 8080:80 -it deniskyashif/puppeteer-azure-func
```

### Retrieve the title of a page

```sh
curl -v http://localhost:8080/api/Examples/Title?url=https://github.com
```

### Take a screenshot of a page

```sh
curl -v http://localhost:8080/api/Examples/Screenshot?url=http://github.com -o ./page.png
```

### Download page as a PDF

```sh
curl -v http://localhost:8080/api/Examples/Pdf?url=http://github.com -o ./page.pdf
```

## Local Development

### Prerequisites

* [Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local#install-the-azure-functions-core-tools)
* [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)

### Run the project

```sh
func start
```

### Add your own functions

```sh
func new --name MyFunction --template "HttpTrigger"
```

PuppeteerSharp [API reference](https://www.puppeteersharp.com/api/index.html).

For building custom images and deploying them on Azure, refer to [this article](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-function-linux-custom-image#run-the-build-command).  


