define(['main'], function(main) {
  console.log('window.webapi', window.webapi);
  $.ajax({
    url: window.webapi + '/Posts/GetAllPosts',
    contentType: 'application/x-www-form-urlencoded',
    data: {},
    type: 'GET',
    async: false,
    success: function(result) {
      console.log('result', result);
    }
  });
});
