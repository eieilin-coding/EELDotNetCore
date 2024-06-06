const tblBlog = "blogs";

//getBlogTable();
//readBlog();
//createBlog();
//updateBlog("8306857c-264b-4bc3-9603-415ec465fa5d", 'abcdd', 'efgh','ijkl');
deleteBlog("da8cf8cd-36df-4efc-a5b7-321f07369929");
deleteBlog("5f2f4919-c2cf-4acf-b82a-f3175741d1a4");

function readBlog(){
    const blogs = localStorage.getItem(tblBlog); 
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
}

    function updateBlog(id, title , author, content){
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
    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x=> x.id === id);
    lst[index] = item;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
    }
    
    function deleteBlog(id){
        const blogs = localStorage.getItem(tblBlog);
        console.log(blogs);

        let lst = [];
        if(blogs !== null){
            lst = JSON.parse(blogs);
        }

        const items = lst.filter(x => x.id === id);
        if(items.length == 0){
            console.log("no data found.");
            return;
        }

        lst = lst.filter(x => x.id !== id);
        const jsonBlog = JSON.stringify(lst);
        localStorage.setItem(tblBlog,jsonBlog);     
    }

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
  }
  
  console.log(uuidv4());