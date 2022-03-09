# RFQ Service #

The service is designed as a component to enable RFQ trading. The motivation was to try to apply [actors](https://github.com/phatboyg/Stact) for this sort of challenge.    
The project is not accomplished and serves for demo purposes only.


### Tooling ###

* MSpec Resharper runner - machine.specifications.runner.resharper
* MSpec templates (http://therightstuff.de/2010/03/03/MachineSpecifications-Templates-For-ReSharper.aspx)
* To disable warnings about tests naming convention follow (http://aspiringcraftsman.com/2010/02/11/resharper-naming-style-for-machine-specifications/)

### TODO ###

* Create a base class in SPECS for database connection management
* Implement supervisor actor for errors handling
* Visitors - Validation (http://lostechies.com/jimmybogard/2007/10/24/entity-validation-with-visitors-and-extension-methods/), TraceVisitor (see Stact)
* Create mappings for Altex 
* Define outgoing messages for communication
