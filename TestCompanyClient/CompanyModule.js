Page.Tabs.CompanyTab.CompanySelect = $('.company-select');

$(document).ready(function () {
    //Company UI functions:
    Page.Tabs.CompanyTab.CompanySelect.change(function () {
        var CompanyId = $(this).children("option").attr('value');
        mediator.publish('CompanySelected', CompanyId);
        //ComapanyModule.SelectCompany(CompanyId);
    });
});

var ComapanyModule = {

    getCompaniesFromJSON: function () {
        var company = JSON.parse(AjaxModule.GetJSON(Page.Urls.CompaniesUrl).responseText);
        $.each(company, function () {
            var option = document.createElement("option");
            option.innerHTML = this.Name;
            option.value = this.Id;
            Page.Tabs.CompanyTab.CompanySelect.append(option);
        });
    }
};

ComapanyModule.getCompaniesFromJSON();
