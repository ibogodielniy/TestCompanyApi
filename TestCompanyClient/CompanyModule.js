var ComapanyModule = {

    init: function(){
        $('.company-select').change(function () {
            var CompanyId = $(".company-select option:selected").val();
            mediator.publish('CompanySelected', CompanyId);
        });
    },

    getCompaniesFromJSON: function () {
        var company = JSON.parse(AjaxModule.GetJSON(API.Urls.CompaniesUrl).responseText);
        $.each(company, function () {
            var option = document.createElement("option");
            option.innerHTML = this.Name;
            option.value = this.Id;
            $('.company-select').append(option);
        });
    }
};

ComapanyModule.getCompaniesFromJSON();
