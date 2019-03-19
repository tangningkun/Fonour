/* jshint esversion: 6 */
define(['main', 'current', 'lay!layer'], function(main, current) {
  var layer = layui.layer;
  var module = {
    _init: function(data) {
      console.log(data);
      if (module._checkform(data)) {
        return;
      }
    },
    _checkform: function(data) {
      if (current._IsEmpty(data.username)) {
        layer.msg('用户名不能为空', { icon: 2 });
        return true;
      }
      if (current._IsEmpty(data.password)) {
        layer.msg('密码不能为空', { icon: 2 });
        return true;
      }
      if (current._IsEmpty(data.confirmpassword)) {
        layer.msg('确认密码不能为空', { icon: 2 });
        return true;
      }
      return false;
    }
  };
  $('#btn-register').click(function() {
    let UserName = $('#form-username')
      .val()
      .trim();
    let PsssWord = $('#form-password')
      .val()
      .trim();
    let ConfirmPsssWord = $('#form-confirmpassword')
      .val()
      .trim();
    module._init({ username: UserName, password: PsssWord, confirmpassword: ConfirmPsssWord });
  });
});
