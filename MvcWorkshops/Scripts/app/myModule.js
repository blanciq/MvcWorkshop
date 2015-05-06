var MyModule = new (function () {
    var self = this;

    var privateField = "private";

    var privateMethod = function() {
        
    }
    self.publicField = "public";
    self.publicMethod = function() {
        
    }


    return self;
})();