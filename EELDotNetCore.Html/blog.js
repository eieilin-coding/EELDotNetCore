const tblBlog = "blogs";

//createBlog();
updateBlog("8306857c-264b-4bc3-9603-415ec465fa5d");

function readBlog(){
    localStorage.getItem(); 
    console.log(blogs);  
}

function createBlog(){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
    
    //1 == '1' (value)
    //1 === '1' (data type)
    let lst = [];
    if(blogs !== null){
         lst = JSON.parse(blogs);
     }

    const requestModel = {
        id: uuidv4(),
        title: "test title",
        author: "test author",
        content: "test content"
    };

    lst.push(requestModel);

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
    // localStorage.setItem("blogs", requestModel);

    function updateBlog(id){
        const blogs = localStorage.getItem(tblBlog);
        console.log(blogs);

        let lst = [];
    if(blogs !== null){
         lst = JSON.parse(blogs);
     }

     const items = lst.filter(x => x.id === id);
     console.log(items);

     console.log(items.length);
     if(items.length == 0){
        console.log("no data found.");
        return;
     }
    const item = item[0];

    }

}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
  }
  
  console.log(uuidv4());