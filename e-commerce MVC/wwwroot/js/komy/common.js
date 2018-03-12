function isEmail(mail) {
    if (/^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(mail))
        return (true);
    return (false)
}

function isPhone(mobile) {
    for (var i = 0; i < mobile.length; i++)
        if ((mobile[i] < '0' || mobile[i] > '9') && mobile[i] !== '+' && mobile[i] !== ' ')
            return false;
    return true;
}

