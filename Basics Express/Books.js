const express = require('express');
const app = express();
const parser = require('body-parser');
app.use(parser.urlencoded({'extended':true}));
app.use(parser.json())

const config={
    server:'192.168.171.36',
    database:'3316',
    driver: 'msnodesqlv8',
    options:{
        trustedConnection:true,
        TrustServerCertificate:true
    }
}
const server = require('mssql/msnodesqlv8');
const pool = new server.ConnectionPool(config);

//app.get('/', (req, res) => res.send("Welcome to Express training"))

app.get('/Book', (req, res) => res.sendFile(__dirname + "/Books.html"));
app.get('/AddBook', (req, res) => res.sendFile(__dirname + "/AddNewBook.html"));
app.get('/TableBook',(req, res) => res.sendFile(__dirname + "/getAllBooks.html"));
// app.get('/FindById',(req, res) => res.sendFile(__dirname + "/FindBook.hmtl"));

//To insert books from user
app.post('/addPost',(req,res)=>{
    const body1 = req.body;
    console.log(body1);
    const quer = `insert into Books values (${body1.txtbid},'${body1.txtbname}' , '${body1.txtbauthor}', ${body1.txtbprice})`;
    pool.connect().then(()=>{
        pool.request().query(quer,(err,result) =>{
            if(err){
                console.error(err);
            }
            else{
                res.send("Inserted Successfully ");
            }
        })
    }).catch((err) => {
        if(err){
            console.log(err);
        }
    })
})

//To display books in tabel form
app.get('/',(req,res) =>{
    debugger;
    pool.connect().then(() =>{
        pool.request().query("select * from Books", (err,result) =>{
            if(err){
                console.error(err);
            }
            else{
                res.send(result.recordset);
            }
        })
    }).catch((err) => {
        if(err){
            console.log(err);
        }
    })
})

//To find Book by id
app.get("/:id",(req,res)=>{
    const id = parseInt(req.params.id);
    pool.connect().then(()=>{
        pool.request().query(`select * from Books where Bid = ${id}`,(err,result)=>{
            if(err){
                console.error(err);
            }
            else{
                res.send(result.recordset);
            }
        })
    }).catch((err) => {
        if(err){
            console.log(err);
        }
})
})

//To Delete Book
app.delete("/:id",(req,res)=>{
    const id = parseInt(req.params.id);
    pool.connect().then(()=>{
        pool.request().query(`delete from Books where Bid = ${id}`,(err,result)=>{
            if(err){
                console.error(err);
            }
            else{
                res.send(result.recordset);
                
            }
        })
    }).catch((err) => {
        if(err){
            console.log(err);
        }
})
})
app.listen(1390, () => console.log("Server is available "));