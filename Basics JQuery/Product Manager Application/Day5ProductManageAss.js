class ProductDetails {
    constructor (id,name,price){
        this.proId = id;
        this.proName = name;
        this.proPrice = price;
    }
}

class ProRepo{
    data = [];
    addEmp(emp){
        this.data.push(emp);
    }
    //addEmp = (emp) => this.data.push(emp);

    getAllEmp(){
        return this.data;
    }

    getEmployee(id){
        for (const emp of this.data) {
            if(emp.proId == id){
                return emp;
            }
        }
        throw `Employee by Id ${id} not found `;

    }
    // empDelete(id){
    //     data.splice(id,1);
    // }
    updateEmployee(emp){
        for (const emprec of this.data) {
            if(emp.proId == emprec.proId){
                emprec.proName = emp.proName;
                emprec.proPrice = emp.proPrice;
                return;
            }
        }
        throw `Employee not found to update `;
    }
}


//Testing part
let instance = new ProRepo();
instance.addEmp(new ProductDetails(23,'Jeans',500));
instance.addEmp(new ProductDetails(24,'shirt',400));
instance.addEmp(new ProductDetails(25,"tops",500));
instance.addEmp(new ProductDetails(26,'Shorts',200));

const Record = instance.getAllEmp();
for (const emp of Record) {
    console.log(emp.proId,emp.proName,emp.proPrice);
}
