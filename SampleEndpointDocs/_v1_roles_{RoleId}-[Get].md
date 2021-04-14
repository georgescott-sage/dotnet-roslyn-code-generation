| [Access Control](../../AccessControl.md) | [Api](../../Api.md) | [Database](../../Database.md) | [Subscriber Packages](../../SubscriberPackages.md) | [Permissions](../../Permissions.md) | [Roles](../../Roles.md) | 
| :-: | :-: | :-: | :-: | :-: | :-: | 
# v1 - Retrieve a role

| Get | /v1/roles/{RoleId} | 
| :-: | :-: | 

> Retrieve a role.

###### Required rights

 Either the principal has the Get Role Policy or 

* If the role is public, the caller must be the role owner.

 * If the role is private, the caller must have a Product Management Control record for the product to which the role is attached. In that PMC record, the caller must be set as the role owner. 

###### Required Access Control policy

Policy name: Get Role

Description: Grants rights to retrieve a role.

Resource: `access-control/role`

Action: `get`

Context:



&nbsp;
| Property | Status | 
| :-- | :-: | 
| Available | Yes | 
| Pending Changes | No | 

&nbsp;

### Path Parameters

| Name | Type | Format | Required | Min | Max | Description | Allowed Values | 
| :-: | :-: | :-: | :-: | :-: | :-: | :- | :- | 
| RoleId | string | uuid | True | - | - | Unique ID of the role. |  | 


### Responses

- [200] - OK

**Body**


> Fields marked with `*` are required and must be specified.


<pre><code>
- Id* [uuid] | Unique ID of the role.
- Name* [string] [min: 1 , max: 255] | Name of the role.
- RequiredContextKeys [array] | Context keys required to allocate the role.
- Owner* [string] [min: 1 , max: 128] | Unique ID of the role owner.
- Public* [boolean] | Specifies whether the role is public or private.
- Products* [array] | Products to which the role is attached.
[
	- Id* [uuid] | Unique ID of the product.
	- Code* [string] [min: 1 , max: 50] | Unique code of the product.
	- IsOwner* [boolean] | Specifies whether the product is the role owner.
]
- CreatedBy* [string] [min: 1 , max: 128] | Unique ID of the principal that created the role.
- CreatedAt* [int64] | The UTC Epoch timestamp (including milliseconds) when the role was created.
- UpdatedBy [string] [max: 128] | Unique ID of the principal that last updated the role.
- UpdatedAt [int64] | The UTC Epoch timestamp (including milliseconds) when the role was last updated.
</code></pre>

**Headers:** &nbsp;&nbsp;N/A

---

- [400] - Bad Request

**Body**


> Fields marked with `*` are required and must be specified.


<pre><code>
- Code* [string] | The unique error code that describes the reason for the error.
- Details [array] | Additional details of the error.
[
	- Field* [string] | The name of the field related to the error.
	- Code* [string] | The unique code that describes the reason for this field error.
]
</code></pre>

**Headers:** &nbsp;&nbsp;N/A

---

- [401] - Unauthorized. Caller is not authenticated with CloudId.

**Body**


> Fields marked with `*` are required and must be specified.


<pre><code>
- Code* [string] | The unique error code that describes the reason for the error.
- Details [array] | Additional details of the error.
[
	- Field* [string] | The name of the field related to the error.
	- Code* [string] | The unique code that describes the reason for this field error.
]
</code></pre>

**Headers:** &nbsp;&nbsp;N/A

---

- [403] - Forbidden. Caller does not have permissions.

**Body**


> Fields marked with `*` are required and must be specified.


<pre><code>
- Code* [string] | The unique error code that describes the reason for the error.
- Details [array] | Additional details of the error.
[
	- Field* [string] | The name of the field related to the error.
	- Code* [string] | The unique code that describes the reason for this field error.
]
</code></pre>

**Headers:** &nbsp;&nbsp;N/A

---

- [404] - Role Not Found

**Body**


> Fields marked with `*` are required and must be specified.


<pre><code>
- Code* [string] | The unique error code that describes the reason for the error.
- Details [array] | Additional details of the error.
[
	- Field* [string] | The name of the field related to the error.
	- Code* [string] | The unique code that describes the reason for this field error.
]
</code></pre>

**Headers:** &nbsp;&nbsp;N/A

---

- [429] - Too many requests.

**Body**


> Fields marked with `*` are required and must be specified.


<pre><code>
- Code* [string] | The unique error code that describes the reason for the error.
- Details [array] | Additional details of the error.
[
	- Field* [string] | The name of the field related to the error.
	- Code* [string] | The unique code that describes the reason for this field error.
]
</code></pre>

**Headers:** &nbsp;&nbsp;N/A

---


### Cache

The following are the cache settings for this endpoint.

TTL:

<pre><code>

300

</code></pre>

Key:

<pre><code>

roles:getbyid:{RoleId}

</code></pre>



---

### Cache Dependencies

The following cache dependencies are required for this endpoint.

<pre><code>
- Roles[RoleId]
</code></pre>


---

### Acceptance Criteria

The following acceptance criteria rules are required for this endpoint.


> If the specified Role can NOT be found, then return a 404 Not Found status code.




> If the specified Role is public and the calling principal is NOT the owner of the specified Role, then return a 403 Forbidden status code.




> If the specified Role is private and the calling principal does NOT have a PMC record for a product that the Role is linked to where PMC.Owner == Role.Owner, then return a 403 Forbidden status code.





---

