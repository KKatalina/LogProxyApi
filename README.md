## LogProxyApi


### Project Structure
LogProxyApi.AirTable - implementation for communication with AirTable database

LogProxyApi.Common - common models and interfaces

LogProxyApi.Sample - web application for testing

LogProxyApi.Web - messages controller implementation

LogProxyApi.*.Tests - unit test for corresponding projects


### Testing
After openning the main page you can test API controller in one of two ways: with available by default user interface or with Swagger.

#### Credentials
As user name any not empty value is accepted.
As password any not empty value is accepted.

#### Via User Interface
To create a message fields **Title** and **Text** must be specified and after clicking **Submit** it will be send to the server. If login was not made it would be asked to provide the credentials. If message was successfully created an alert will appear with new message id. In case or error alert will contain an error message.

To view the list of all messages **Refresh List** button must be clicked. If login was not made it would be asked to provide the credentials. In case of success the messages will appear in the table otherwise an alert with error will be shown.

#### Via Swagger
Link "Swagger" on the top right of the page opens page with API documentation. This page allows to test available endpoints.

### Other
Paging was not specified in the task, that is why it was not implemented.
