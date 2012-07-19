Backbone.Validation.Metadata
============================

Add the ability to use DataAnnotations validation with your Backbone.js models using Backbone.Validation (https://github.com/thedersen/backbone.validation), the sample should give you a good idea of how to get up and running. The sample is also using a script I found to add support for twitter bootstrap styling with validation errors, this was found here: https://gist.github.com/2909552

Note: I only adapt a couple types of validators atm (required, range, regex), could move more across but for the moment (feel free to submit a pull request).

##Usage

1. Add the handler for the metadata script
2. Register the models you would like to export metadata for in your application
3. Include the metadata script after backbone.validation.js
4. Call Backbone.Validation.attachMetadataValidators in your models to attach the DataAnnotations client side validators.