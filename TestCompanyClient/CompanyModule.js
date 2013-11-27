Page.Tabs.CompanyTab.CompanySelect = $('.company-select');

$(document).ready(function () {
    Page.Tabs.CompanyTab.CompanySelect.change(function () {
        var CompanyId = $(".company-select option:selected").val();
        mediator.publish('CompanySelected', CompanyId);
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
