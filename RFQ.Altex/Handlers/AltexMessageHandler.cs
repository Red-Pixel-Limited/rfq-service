﻿namespace RFQ.Altex.Handlers
﻿{
﻿    using System;
﻿    using Communication.Messages;
﻿    using global::Altex.MessageLibrary;
﻿    using Mappings.Messages;

﻿    class AltexMessageHandler<T> : IAltexMessageHandler 
         where T : CommunicationMessage
﻿    {
﻿        readonly Action<T> _proceedRequest;
﻿        readonly IAltexMessageMapper<T> _mapper;

﻿        internal AltexMessageHandler(Action<T> proceedRequest, 
                                     IAltexMessageMapper<T> mapper)
﻿        {
﻿            _proceedRequest = proceedRequest;
﻿            _mapper = mapper;
﻿        }

﻿        public void Handle(MsgBase altexMessage)
﻿        {
﻿            var communicationMessage = _mapper.Map(altexMessage);
﻿            _proceedRequest(communicationMessage);
﻿        }
﻿    }
﻿}
