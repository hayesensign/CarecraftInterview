function printQuestionInput()
{
  var webdriver = require(‘selenium-webdriver’);
  var browser_name = new webdriver.Builder();
  withCapabilities(webdriver.Capabilities.chrome()).build();
  browser.get(‘file:///C:/Users/hayes/source/repos/MetalQuoting.htm’);
  document.getElementById("question).text.print();
}

function printAnswerInput()
{
  var webdriver = require(‘selenium-webdriver’);
  var browser_name = new webdriver.Builder();
  withCapabilities(webdriver.Capabilities.chrome()).build();
  browser.get(‘file:///C:/Users/hayes/source/repos/MetalQuoting.htm’);
  document.getElementById("question).text.print();
}
