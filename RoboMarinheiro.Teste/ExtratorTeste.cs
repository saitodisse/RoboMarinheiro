using NUnit.Framework;
using RoboMarinheiro.Dominio.Entidades;

namespace RoboMarinheiro.Dominio.Teste
{
    [TestFixture]
    public class ExtratorTeste
    {
        [Test]
        public void deve_buscar_regex_passada()
        {
            const string html = "<!DOCTYPE html>\n<html lang=\"en-US\">\n<head>\n<title>Tryit Editor v1.5</title>\n<link rel=\"stylesheet\" type=\"text/css\" href=\"/tryit.css\" />\n<script type=\"text/javascript\">\nfunction displayad()\n{\nvar t=document.getElementById(\"pre_code\").value;\nt=t.replace(/=/gi,\"w3equalsign\")\nt=t.replace(/script/gi,\"w3scripttag\")\n\t\ndocument.getElementById(\"code\").value=t;\n//document.getElementById(\"adframe\").src=\"/tryitbanner.asp?secid=tryhtml&rnd=\" + Math.random();\ndocument.getElementById(\"tryitform\").action=\"tryit_view.asp?x=\" + Math.random();\n}\n</script>\n</head>\n\n<body>\n<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\n<tr>\n<td align=\"center\">\n<iframe id=\"adframe\" style=\"background-color:#ffffff\" height=\"98\" width=\"960\" marginwidth=\"0\" marginheight=\"0\" frameborder=\"0\" scrolling=\"no\" \nsrc=\"/tryitbanner.asp?secid=tryhtml&rnd=0.2478144\"></iframe>\n\n</td>\n</tr>\n</table>\n\n<table border=\"0\" class=\"maintable\" cellpadding=\"3px\" cellspacing=\"3px\">\n<tr>\n<td width=\"50%\">\n\n<form style=\"margin:0px\" action=\"tryit_view.asp\" method=\"post\" target=\"view\" id=\"tryitform\">\n<input style=\"margin-bottom:5px;font-family:verdana;\" name=\"submit\" type=\"submit\" value=\"Edit and Click Me >>\" onclick=\"displayad()\">\n<textarea class=\"code_input\" width=\"100%\" height=\"400px\" id=\"pre_code\" wrap=\"logical\">\n<html>\n<body>\n\n<h1>My First Heading</h1>\n\n<p>My first paragraph.</p>\n\n</body>\n</html>\n\n</textarea>\n<input type=\"hidden\" name=\"code\" id=\"code\" />\n<input type=\"hidden\" id=\"bt\" name=\"bt\" />\n</form>\n\n</td>\n\n<td valign=\"top\">\n<p class=\"result_header\">Your Result:</p>\n<iframe class=\"result_output\" width=\"100%\" height=\"400px\" frameborder=\"0\" name=\"view\" src=\"tryit_view.asp?filename=tryhtml_intro\"></iframe>\n</td>\n</tr>\n<tr>\n<td align=\"left\" class=\"bottomtext\">\nEdit the code above and click to see the result.\n</td>\n<td align=\"right\" class=\"bottomtext\">\n<a style=\"color:#617f10\" href=\"http://www.w3schools.com\">W3Schools.com</a> - Try it yourself&nbsp;\n</td>\n\n</tr>\n</table>\n\n</body>\n</html>";
            var extrator = new Extrator();
            var resultado = extrator.ExtrairPrimeiroGrupo(html, @"<p>(.*)?<\/p>");
            Assert.AreEqual("My first paragraph.", resultado);
        }
    }
}
