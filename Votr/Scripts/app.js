var app = angular.module("VotrApp", []);

app.controller("PollCtrl", function () {

    var self = this;

    self.showPopup = function () {
        window.alert();
    }
<<<<<<< HEAD

    self.Options = [];

    self.AddOption = function (e) {

=======
    self.Options = [];

    self.AddOption = function (e) {
        // Get value from input field
>>>>>>> a813e6c2d88c3b5b1209cc349493afe36c032139
        var input_val = $("#firstoption").val();
        var incrementer = 1;
        self.Options.push(input_val);
        $("#firstoption").val("");
<<<<<<< HEAD
        e.preventDefault();
    }

=======
        // Then append it onto the Options object
        e.preventDefault();

    }
>>>>>>> a813e6c2d88c3b5b1209cc349493afe36c032139
});