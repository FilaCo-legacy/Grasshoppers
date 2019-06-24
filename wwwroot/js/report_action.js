$(document).ready(function () {

    $("#btnExport").click(fnExcelReport)
    
    function ParseDataTable() {
        var tab_text="";

        var tab = document.getElementById('dataTable'); // id of table

        for(var cur = 0 ; cur < tab.rows.length ; cur++)
        {
            $("td:visible, th:visible", tab.rows[cur]).each(function () {
                tab_text += this.outerHTML;
            });
            tab_text+="</tr>";
        }

        tab_text=tab_text+"</table>";
        tab_text= tab_text.replace(/<a[^>]*>|<\/a>/g, "");


        return tab_text;
    }
    
    function fnExcelReport()
    {
        var uri = 'data:application/vnd.ms-excel;base64,';
        var template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>';
        var base64 = function(s) {
            return window.btoa(unescape(encodeURIComponent(s)))
        };

        var format = function(s, c) {
            return s.replace(/{(\w+)}/g, function(m, p) {
                return c[p];
            })
        };

        var htmls = ParseDataTable();

        var ctx = {
            worksheet : 'Worksheet',
            table : htmls
        }


        var link = document.createElement("a");
        link.download = "export.xls";
        link.href = uri + base64(format(template, ctx));
        link.click();
    }
    
});