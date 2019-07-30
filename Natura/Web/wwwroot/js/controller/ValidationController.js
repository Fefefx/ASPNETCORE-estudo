class ValidationController {
    constructor(classDelete, msg) {
        this.btnsDelete = document.getElementsByClassName(classDelete);
        this.addValidation(msg, this.btnsDelete);
    }
    addValidation(msg,elements){
        [...elements].forEach(element=>{
            element.addEventListener('click',e=>{
                if(!confirm(msg))
                    e.preventDefault();
            });
        });
    }
}