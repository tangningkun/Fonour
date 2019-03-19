/* jshint esversion: 6 */
define(['main', 'current', 'lay!layer'], function(main, current) {
  var layer = layui.layer;
  var module = {
    _init: function(username, password) {
      if (module._checkform(username, password)) {
        return;
      }
      $.ajax({
        url: '/Account/CheckLogin',
        contentType: 'application/x-www-form-urlencoded',
        data: {
          UserName: username,
          Password: password
        },
        type: 'POST',
        async: false,
        success: function(result) {
          if (result.code == 200) {
            location.href = '/Home/Index';
          } else if (result.code != 202) {
            layer.msg(result.message, { icon: 2 });
          } else {
            layer.msg('系统错误,请重新登录！', { icon: 2 });
          }
        }
      });
    },
    _checkform: function(username, password) {
      if (current._IsEmpty(username)) {
        layer.msg('用户名不能为空', { icon: 2 });
        return true;
      }
      if (current._IsEmpty(password)) {
        layer.msg('密码不能为空', { icon: 2 });
        return true;
      }
      return false;
    },
    isEmpty: function(obj) {
      if (typeof obj == 'undefined' || obj == null || obj == '') {
        return true;
      } else {
        return false;
      }
    }
  };
  $('#btn-login').click(function() {
    let UserName = $('#form-username')
      .val()
      .trim();
    let PsssWord = $('#form-password')
      .val()
      .trim();
    module._init(UserName, PsssWord);
  });
});
