class Home
{
    constructor()
    {
        this.animateSections();
    }

    animateSections()
    {
        //dando uma animada na bagaça...
        setTimeout(() => {
            $('#linhas').addClass('in');
            setTimeout(() => {
                $('.card').addClass('in');
            },300);
        },300);        
    }
}
