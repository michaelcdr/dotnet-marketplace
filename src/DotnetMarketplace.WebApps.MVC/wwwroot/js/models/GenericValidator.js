class GenericValidator
{
    constructor(formEl)
    {
        this._formEl = formEl;
    }

    validate()
    {
        let validateResponse = { isValid:true };
        this._formEl.find('*[data-required="true"]').removeClass('is-invalid');
        this._formEl.find('*[data-required="true"]').each((index,el) => {
            if ($(el).val() === ''){
                $(el).addClass('is-invalid');
                validateResponse.isValid = false;
            }
        });
        return validateResponse;
    }
}