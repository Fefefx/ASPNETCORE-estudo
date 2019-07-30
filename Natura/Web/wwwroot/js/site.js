// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

class ValidationController{
    constructor(classDelete,msg){
        this.btnsDelete = document.getElementsByClassName(classDelete);
        this.addValidation(msg,this.btnsDelete);
    }
    addValidation(msg,element){
    	[...element].forEach(e=>{
        	e.addEventListener('click',e=>{
            	if(!confirm(msg)){
              		e.preventDefault();   
            	}
        	});
    	});
    }
}
