﻿namespace RFQ.Altex.Mappings.Messages.Incoming
﻿{
﻿    using Communication.Messages.Incoming;
﻿    using Communication.Options;
﻿    using global::Altex.MessageLibrary;
﻿    using global::Altex.MessageLibrary.Msg.Norm;

﻿    internal sealed class GTNHeartbeatMapper : IAltexMessageMapper<GTNHeartbeat>
﻿    {
﻿        public GTNHeartbeat Map(MsgBase altexMessage)
﻿        {
﻿            var evspMessage = (EVSPHeartbeat)altexMessage;

﻿            return new GTNHeartbeat(evspMessage.RequestId,
                    ﻿                evspMessage.VenueId,
                    ﻿                evspMessage.ProductId,
                    ﻿                evspMessage.InstanceId,
                    ﻿                evspMessage.DisplayName,
                    ﻿                evspMessage.HeartbeatInterval,
                    ﻿                evspMessage.LoadFactor,
                    ﻿                GTNStatus.Attention, //evspMessage.Status,
                    ﻿                evspMessage.ErrorCode,
                    ﻿                evspMessage.ErrorReason);
﻿        }
﻿    }
﻿}
