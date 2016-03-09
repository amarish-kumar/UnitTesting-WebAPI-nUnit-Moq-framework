window.ApplicationSettings =
{
    ApiDomain: "localhost:19260", 
    ApiURL: function () {
        return "http://" + this.ApiDomain;
    }
};